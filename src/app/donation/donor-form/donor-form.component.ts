import {Component, DestroyRef,  inject, viewChild} from '@angular/core';
import {
  FormsModule,
  NgForm,
} from '@angular/forms';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

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
  constructor(private router: Router) {}



  onSubmit() {

    if (this.form().valid) {
      const donorData = {
        name: this.form().value.name,
        organization: this.form().value.organization || null, // Optional field
      };


      const subscription = this.httpClient.post('https://localhost:7240/api/Donor', donorData).subscribe({
        next: (response: any) => {
          console.log('Donor data submitted successfully', response);
          localStorage.setItem('donorID', response.donorID);
          this.router.navigate(['/donation-form']);
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

  onCancel() {
    this.router.navigate(['/'])
  }
}
