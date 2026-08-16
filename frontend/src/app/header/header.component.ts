import { Component, OnInit, inject } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { RouterLink } from '@angular/router';

import { ModalService } from '../modal.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [ButtonModule, RouterLink],
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit {
  private readonly modal = inject(ModalService);

  /** Which donation modal to open depends on whether a donor is registered. */
  donationTarget: 'donor-registration' | 'donation-form' = 'donor-registration';

  navItems = [
    { label: 'Home', icon: 'pi pi-home', active: true },
    { label: 'Review Request', action: () => this.modal.open('request-status') },
    { label: 'THE BIG FEATURE', route: '/big-feature' },
    { label: 'About Us' },
    { label: 'Blog' },
    { label: 'Contact Us' },
  ];

  ngOnInit(): void {
    const donorID = localStorage.getItem('donorID');
    this.donationTarget = donorID ? 'donation-form' : 'donor-registration';
  }

  onReviewRequest(): void {
    this.modal.open('request-status');
  }

  onDonate(): void {
    this.modal.open(this.donationTarget);
  }
}
