import { Injectable, signal } from '@angular/core';

/**
 * Central, signal-based modal state. Components call `open()` to show a
 * dialog and `close()` to dismiss. The host (AppComponent) renders the
 * PrimeNG dialogs bound to these signals, so modal logic stays decoupled
 * from routing and individual components only need to emit/trigger.
 */
export type ModalKind =
  | 'request-form'
  | 'donor-registration'
  | 'donation-form'
  | 'request-status';

@Injectable({ providedIn: 'root' })
export class ModalService {
  /** Currently open modal, or null when none. */
  readonly active = signal<ModalKind | null>(null);

  open(kind: ModalKind): void {
    this.active.set(kind);
  }

  close(): void {
    this.active.set(null);
  }

  isOpen(kind: ModalKind): boolean {
    return this.active() === kind;
  }
}
