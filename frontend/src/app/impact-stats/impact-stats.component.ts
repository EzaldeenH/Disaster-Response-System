import {
  AfterViewInit,
  Component,
  ElementRef,
  NgZone,
  OnDestroy,
  ViewChild,
  inject,
  signal,
} from '@angular/core';

interface Stat {
  /** Numeric target used for the count-up animation. */
  readonly target: number;
  /** Prefix shown before the number (e.g. "$"). */
  readonly prefix?: string;
  /** Suffix shown after the number (e.g. "+", "M", "h"). */
  readonly suffix?: string;
  readonly label: string;
  readonly icon: string;
  /** When true, the stat renders in red with a pulsing live dot. */
  readonly live?: boolean;
}

@Component({
  selector: 'app-impact-stats',
  standalone: true,
  imports: [],
  templateUrl: './impact-stats.component.html',
})
export class ImpactStatsComponent implements AfterViewInit, OnDestroy {
  private readonly zone = inject(NgZone);

  @ViewChild('statsGrid', { static: true })
  private readonly statsGrid?: ElementRef<HTMLElement>;

  /** Animated display values — one signal per stat, updated by the count-up. */
  protected readonly displayValues: ReadonlyArray<ReturnType<typeof signal<number>>> = [];

  protected readonly stats: ReadonlyArray<Stat> = [
    { target: 12400, suffix: '+', label: 'People Helped', icon: 'pi pi-users' },
    { target: 47, label: 'Disasters Responded To', icon: 'pi pi-bolt' },
    { target: 2.8, prefix: '$', suffix: 'M', label: 'Aid Distributed', icon: 'pi pi-wallet' },
    { target: 12, label: 'Active Responses', icon: 'pi pi-bolt', live: true },
  ];

  constructor() {
    this.displayValues = this.stats.map(() => signal(0));
  }

  ngAfterViewInit(): void {
    if (!this.statsGrid) return;

    // Respect reduced-motion: skip the animation, jump to final values.
    const prefersReduced =
      typeof window !== 'undefined' &&
      window.matchMedia?.('(prefers-reduced-motion: reduce)').matches;

    if (prefersReduced) {
      this.stats.forEach((s, i) => this.displayValues[i].set(s.target));
      return;
    }

    const observer = new IntersectionObserver(
      (entries) => {
        for (const entry of entries) {
          if (entry.isIntersecting) {
            this.startCountUp();
            observer.disconnect();
            break;
          }
        }
      },
      { threshold: 0.3 },
    );
    observer.observe(this.statsGrid.nativeElement);
  }

  ngOnDestroy(): void {
    // IntersectionObserver auto-cleans on node removal; nothing to dispose here.
  }

  private startCountUp(): void {
    const duration = 1200;
    const start = performance.now();

    // Run the rAF loop outside Angular's zone to avoid triggering CD each frame;
    // signals still notify consumers (the template) on set().
    this.zone.runOutsideAngular(() => {
      const tick = (now: number) => {
        const elapsed = now - start;
        const t = Math.min(elapsed / duration, 1);
        // easeOutCubic — fast start, gentle settle
        const eased = 1 - Math.pow(1 - t, 3);

        this.stats.forEach((s, i) => {
          this.displayValues[i].set(s.target * eased);
        });

        if (t < 1) {
          requestAnimationFrame(tick);
        } else {
          this.stats.forEach((s, i) => this.displayValues[i].set(s.target));
        }
      };
      requestAnimationFrame(tick);
    });
  }

  /**
   * Formats a numeric display value for rendering: integers get thousands
   * separators, fractional values (e.g. 2.8M) keep one decimal.
   */
  protected format(stat: Stat, value: number): string {
    const isFractional = !Number.isInteger(stat.target);
    const formatted = isFractional
      ? value.toFixed(1)
      : Math.round(value).toLocaleString('en-US');
    return `${stat.prefix ?? ''}${formatted}${stat.suffix ?? ''}`;
  }
}
