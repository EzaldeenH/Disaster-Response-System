import {Component, DestroyRef, inject, viewChild} from '@angular/core';
import {
  FormsModule,
  NgForm,
} from '@angular/forms';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-donor-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './donor-form.component.html',
  styleUrls: ['./donor-form.component.css'],
})
export class DonorFormComponent {
  private destroyRef = inject(DestroyRef);
  private form = viewChild.required<NgForm>('form');
  private httpClient = inject(HttpClient);



  onSubmit() {
    if (this.form().valid) {
      const donorData = {
        name: this.form().value.name,
        organization: this.form().value.organization || null, // Optional field
      };

      // Save the donor's name in local storage
      localStorage.setItem('donorName', donorData.name);

      // Post the donor data to the server
      const subscription = this.httpClient.post('https://localhost:7240/api/Donor', donorData).subscribe({
        next: (response) => {
          console.log('Donor data submitted successfully', response);
        },
        error: (error) => {
          console.error('Error submitting donor data', error);
        },
      });

      this.destroyRef.onDestroy(() => {
        subscription.unsubscribe();
      });
    }
  }
}
