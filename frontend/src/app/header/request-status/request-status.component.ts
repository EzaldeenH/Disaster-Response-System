import { Component, AfterViewInit, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { TagModule } from 'primeng/tag';
import { MessageModule } from 'primeng/message';

import { ModalService } from '../../modal.service';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-request-status',
  standalone: true,
  imports: [DialogModule, ButtonModule, TagModule, MessageModule],
  templateUrl: './request-status.component.html',
})
export class RequestStatusComponent implements AfterViewInit {
  private readonly http = inject(HttpClient);
  private readonly modal = inject(ModalService);

  requestID: string | null = null;
  readonly status = signal<string | null>(null);
  readonly error = 'No active request found.';

  get visible(): boolean {
    return this.modal.isOpen('request-status');
  }

  set visible(value: boolean) {
    if (!value && this.modal.isOpen('request-status')) {
      this.modal.close();
    }
  }

  ngAfterViewInit(): void {
    this.requestID = window.localStorage.getItem('requestID');
    if (this.requestID) {
      this.getRequestStatus(this.requestID);
    }
  }

  getRequestStatus(requestID: string): void {
    this.http.get(`${environment.apiUrl}/Request/${requestID}`).subscribe({
      next: (response: any) => {
        this.status.set(response.requestActive ? 'active' : 'closed');
      },
      error: (error) => console.error('Error retrieving request status', error),
    });
  }

  onOk(): void {
    this.modal.close();
  }
}
