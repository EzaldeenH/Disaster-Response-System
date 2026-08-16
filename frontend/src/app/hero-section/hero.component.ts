import { Component, OnInit, inject } from '@angular/core';
import { ButtonModule } from 'primeng/button';

import { ModalService } from '../modal.service';

@Component({
  selector: 'app-hero-section',
  standalone: true,
  imports: [ButtonModule],
  templateUrl: './hero.component.html',
})
export class HeroComponent implements OnInit {
  private readonly modal = inject(ModalService);
  protected previousRequestID: string | null = null;

  ngOnInit(): void {
    this.previousRequestID = window.localStorage.getItem('requestID');
  }

  onRequestHelp(): void {
    if (!this.previousRequestID) {
      this.modal.open('request-form');
    }
  }

  onDonate(): void {
    const donorID = window.localStorage.getItem('donorID');
    this.modal.open(donorID ? 'donation-form' : 'donor-registration');
  }
}
