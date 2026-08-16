import { Component, OnDestroy, OnInit, signal } from '@angular/core';

/**
 * Thin live-operations strip rendered directly above the hero.
 *
 * Cycles through a static list of active response regions every few
 * seconds so the page reads as "currently working" without any backend
 * dependency. The pulsing amber dot is the only motion on the bar.
 */
@Component({
  selector: 'app-alert-bar',
  standalone: true,
  templateUrl: './alert-bar.component.html',
})
export class AlertBarComponent implements OnInit, OnDestroy {
  protected readonly activeRegions = [
    'Turkey–Syria earthquake response',
    'Pakistan monsoon flooding',
    'Horn of Africa drought relief',
    'Philippines typhoon recovery',
  ];

  protected readonly current = signal(this.activeRegions[0]);
  private index = 0;
  private timer?: ReturnType<typeof setInterval>;

  ngOnInit(): void {
    this.timer = setInterval(() => {
      this.index = (this.index + 1) % this.activeRegions.length;
      this.current.set(this.activeRegions[this.index]);
    }, 4000);
  }

  ngOnDestroy(): void {
    if (this.timer) clearInterval(this.timer);
  }
}
