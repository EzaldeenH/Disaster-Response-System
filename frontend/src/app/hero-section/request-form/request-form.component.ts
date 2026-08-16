import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { SelectModule } from 'primeng/select';
import { RadioButtonModule } from 'primeng/radiobutton';
import { MessageModule } from 'primeng/message';

import { ModalService } from '../../modal.service';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-request-form',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    DialogModule,
    ButtonModule,
    InputTextModule,
    SelectModule,
    RadioButtonModule,
    MessageModule,
  ],
  templateUrl: './request-form.component.html',
})
export class RequestFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly http = inject(HttpClient);
  private readonly modal = inject(ModalService);

  private previousRequestID: string | null = null;

  readonly housingOptions = [
    { label: 'House intact, but experiencing financial difficulties', value: 'intact' },
    { label: 'House damaged, but inhabitable', value: 'damaged' },
    { label: 'House destroyed or uninhabitable', value: 'uninhabitable' },
    { label: 'Homeless', value: 'homeless' },
  ];

  readonly yesNo = [
    { label: 'Yes', value: true },
    { label: 'No', value: false },
  ];

  readonly form = this.fb.group({
    Name: ['', [Validators.required, Validators.minLength(3)]],
    AdultCount: [1, [Validators.required, Validators.min(1), Validators.max(10)]],
    ChildCount: [0, [Validators.required, Validators.min(0), Validators.max(10)]],
    ElderlyCount: [0, [Validators.required, Validators.min(0), Validators.max(10)]],
    DisabilityCount: [0, [Validators.required, Validators.min(0), Validators.max(10)]],
    HousingStatus: ['', Validators.required],
    BasicNeedsAccess: [null as boolean | null, Validators.required],
    MedicalNeeds: [null as boolean | null, Validators.required],
    Urgency: [null as boolean | null, Validators.required],
  });

  ngOnInit(): void {
    this.previousRequestID = window.localStorage.getItem('requestID');
  }

  get visible(): boolean {
    return this.modal.isOpen('request-form') && !this.previousRequestID;
  }

  set visible(value: boolean) {
    if (!value) {
      this.modal.close();
    }
  }

  onSubmit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const payload = this.form.getRawValue();

    this.http.post(`${environment.apiUrl}/Request`, payload).subscribe({
      next: (response: any) => {
        window.localStorage.setItem('requestID', response.requestID);
        this.previousRequestID = response.requestID;
        this.modal.close();
      },
      error: (error) => console.error('Error submitting request data', error),
    });
  }

  onCancel(): void {
    this.modal.close();
  }
}
