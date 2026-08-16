import { Component } from '@angular/core';

@Component({
  selector: 'app-testimonials',
  standalone: true,
  imports: [],
  templateUrl: './testimonials.component.html',
})
export class TestimonialsComponent {
  readonly testimonials = [
    {
      quote:
        'Within two days of the earthquake, Helping Hands was on the ground with tents, blankets, and hot meals. They were the first to reach our village.',
      name: 'Amara K.',
      role: 'Earthquake Survivor, Turkey',
    },
    {
      quote:
        'I volunteered after the hurricane. The team is organized, compassionate, and genuinely committed to getting help where it is needed fastest.',
      name: 'Dr. Luis Mendoza',
      role: 'Field Volunteer, Haiti',
    },
    {
      quote:
        'After losing our home, we had nowhere to go. Helping Hands gave us shelter and helped us rebuild. I will never forget what they did.',
      name: 'Fatima R.',
      role: 'Flood Survivor, Bangladesh',
    },
  ];
}
