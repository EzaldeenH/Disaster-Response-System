import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [FormsModule, ButtonModule, InputTextModule],
  templateUrl: './footer.component.html',
})
export class FooterComponent {
  email = '';

  readonly footerLinks = [
    { label: 'About us', href: '#about' },
    { label: 'Help Center', href: '#help' },
    { label: 'Contact us', href: '#contact' },
    { label: 'FAQs', href: '#faq' },
    { label: 'Careers', href: '#careers' },
  ];

  readonly socials = [
    { icon: 'pi pi-facebook', label: 'Facebook', href: '#' },
    { icon: 'pi pi-twitter', label: 'Twitter', href: '#' },
    { icon: 'pi pi-instagram', label: 'Instagram', href: '#' },
    { icon: 'pi pi-linkedin', label: 'LinkedIn', href: '#' },
  ];

  subscribeToNewsletter(): void {
    // TODO: wire to backend newsletter endpoint.
    this.email = '';
  }
}
