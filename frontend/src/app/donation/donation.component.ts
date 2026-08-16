import { Component, inject } from '@angular/core';

import { ModalService } from '../modal.service';

@Component({
  selector: 'app-donation',
  standalone: true,
  imports: [],
  templateUrl: './donation.component.html',
})
export class DonationComponent {
  private readonly modal = inject(ModalService);

  readonly amounts = ['$25', '$50', '$100', '$250'];

  /** Static fundraising goal — gives the section a "we're not done yet" tension. */
  readonly goal = 1_200_000;
  readonly raised = 847_000;

  get raisedFormatted(): string {
    return '$' + this.raised.toLocaleString('en-US');
  }

  get goalFormatted(): string {
    return '$' + this.goal.toLocaleString('en-US');
  }

  get progressPercent(): number {
    return Math.round((this.raised / this.goal) * 100);
  }

  onDonate(): void {
    const donorID = localStorage.getItem('donorID');
    this.modal.open(donorID ? 'donation-form' : 'donor-registration');
  }

  onQuickDonate(): void {
    this.onDonate();
  }
}
