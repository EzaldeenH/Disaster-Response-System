import {
  Component,
  inject,
  signal,
  AfterViewInit
} from '@angular/core';
import {FormsModule} from "@angular/forms";
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-request-status',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './request-status.component.html',
  styleUrl: './request-status.component.css'
})
export class RequestStatusComponent implements AfterViewInit{
  requestID: any;
  status = signal< null | string >(null);
  error = 'No active request found';
  private httpClient = inject(HttpClient);
  private router = inject(Router);

  ngAfterViewInit() {
    this.requestID = window.localStorage.getItem('requestID');
    if (this.requestID) {
      this.getRequestStatus(this.requestID);
    }
  }

  getRequestStatus(requestID: string) {
    this.httpClient.get(`https://localhost:7240/api/Request/${requestID}`).subscribe({
      next: (response: any) => {
        if (response.requestActive) {
          this.status.set('active');
        }
        console.log('Request status retrieved successfully', response);
      },
      error: (error) => {
        console.error('Error retrieving request status', error);
      }
    });
  }

  onOk() {
    this.router.navigate(['/']);
  }

  onCancel() {
    this.router.navigate(['/']);
  }
}
