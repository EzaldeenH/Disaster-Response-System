import {Component, DestroyRef, inject, viewChild} from '@angular/core';
import {FormsModule, NgForm} from "@angular/forms";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-donation-form',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './donation-form.component.html',
  styleUrl: './donation-form.component.css'
})
export class DonationFormComponent {
  private destroyRef = inject(DestroyRef);
  private form = viewChild.required<NgForm>('form');
  private httpClient = inject(HttpClient);

  onSubmit() {
    if (this.form().valid) {
      const donationData = {
        donationAmount: this.form().value.amount,
        donor: localStorage.getItem('donorID')
      };

      // Post the donation data to the server
      const subscription = this.httpClient.post('https://localhost:7240/api/Donation', donationData).subscribe({
        next: (response) => {
          console.log('Donation data submitted successfully', response);
        },
        error: (error) => {
          console.error('Error submitting donation data', error);
        },
      });

      this.destroyRef.onDestroy(() => {
        subscription.unsubscribe();
      });
    }
  }
}
