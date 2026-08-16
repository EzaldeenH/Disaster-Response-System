import { Component, DestroyRef, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { MessageModule } from 'primeng/message';

import { ModalService } from '../../modal.service';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-donor-form',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    DialogModule,
    ButtonModule,
    InputTextModule,
    MessageModule,
  ],
  templateUrl: './donor-form.component.html',
})
export class DonorFormComponent {
  private readonly fb = inject(FormBuilder);
  private readonly http = inject(HttpClient);
  private readonly modal = inject(ModalService);
  private readonly destroyRef = inject(DestroyRef);

  readonly form = this.fb.nonNullable.group({
    name: ['', Validators.required],
    organization: [''],
  });

  get visible(): boolean {
    return this.modal.isOpen('donor-registration');
  }

  set visible(value: boolean) {
    if (!value && this.modal.isOpen('donor-registration')) {
      this.modal.close();
    }
  }

  onSubmit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const payload = this.form.getRawValue();

    this.http
      .post(`${environment.apiUrl}/Donor`, payload)
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe({
        next: (response: any) => {
          localStorage.setItem('donorID', response.donorID);
          // Chain straight into the donation amount modal.
          this.modal.open('donation-form');
        },
        error: (error) => console.error('Error submitting donor data', error),
      });
  }

  onCancel(): void {
    this.modal.close();
  }
}
