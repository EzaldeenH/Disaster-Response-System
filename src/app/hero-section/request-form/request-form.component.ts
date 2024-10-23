import {afterNextRender, Component, inject, OnInit, output, viewChild} from '@angular/core';
import {FormsModule, NgForm, ReactiveFormsModule} from "@angular/forms";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-request-form',
  standalone: true,
    imports: [
        FormsModule,
        ReactiveFormsModule
    ],
  templateUrl: './request-form.component.html',
  styleUrl: './request-form.component.css'
})
export class RequestFormComponent implements OnInit {
  onRequestFinished = output<void>();
  private form = viewChild.required<NgForm>('form');
  private httpClient = inject(HttpClient);
  private previousRequestID : string | null = null;

  ngOnInit() {
    afterNextRender(() => {
      this.previousRequestID = window.localStorage.getItem('requestID');
    })
  }

  onSubmit() {
    if (this.form().valid && !this.previousRequestID) {
      const requestData = this.form().value;

      this.httpClient.post('https://localhost:7240/api/Request', requestData).subscribe({
        next: (response: any) => {
          console.log('Request data submitted successfully', response);
          window.localStorage.setItem('requestID', response.RequestID);
        },
        error: (error) => {
          console.error('Error submitting request data', error);
        },
      });

      this.onRequestFinished.emit();
    }
  }

  onCancel() {
    this.onRequestFinished.emit();
  }
}

