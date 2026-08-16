import { Component, DestroyRef, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { InputNumberModule } from 'primeng/inputnumber';
import { MessageModule } from 'primeng/message';

import { ModalService } from '../../modal.service';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-donation-form',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    DialogModule,
    ButtonModule,
    InputNumberModule,
    MessageModule,
  ],
  templateUrl: './donation-form.component.html',
})
export class DonationFormComponent {
  private readonly fb = inject(FormBuilder);
  private readonly http = inject(HttpClient);
  private readonly modal = inject(ModalService);
  private readonly destroyRef = inject(DestroyRef);

  readonly form = this.fb.nonNullable.group({
    amount: [null as number | null, [Validators.required, Validators.min(1)]],
  });

  get visible(): boolean {
    return this.modal.isOpen('donation-form');
  }

  set visible(value: boolean) {
    if (!value && this.modal.isOpen('donation-form')) {
      this.modal.close();
    }
  }

  onSubmit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const payload = {
      donationAmount: this.form.controls.amount.value,
      donor: localStorage.getItem('donorID'),
    };

    this.http
      .post(`${environment.apiUrl}/Donation`, payload)
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe({
        next: () => this.modal.close(),
        error: (error) => console.error('Error submitting donation data', error),
      });
  }

  onCancel(): void {
    this.modal.close();
  }
}
