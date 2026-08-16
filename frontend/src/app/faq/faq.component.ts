import { Component } from '@angular/core';

@Component({
  selector: 'app-faq',
  standalone: true,
  imports: [],
  templateUrl: './faq.component.html',
})
export class FaqComponent {
  readonly cards = [
    {
      icon: 'pi pi-chart-line',
      title: 'See Your Impact',
      description:
        'See how your donations are making a difference in communities affected by natural disasters. We publish transparent reports on every dollar spent.',
      buttonText: 'Learn More',
    },
    {
      icon: 'pi pi-users',
      title: 'Volunteer Your Time',
      description:
        'Discover how you can contribute your time and skills to help those in need. From medical professionals to logistics experts, there is a role for everyone.',
      buttonText: 'Learn More',
    },
    {
      icon: 'pi pi-wallet',
      title: 'Raise Funds Effectively',
      description:
        'Find out how to organize and raise funds effectively for disaster relief. We provide toolkits and support for community-led fundraising campaigns.',
      buttonText: 'Learn More',
    },
    {
      icon: 'pi pi-megaphone',
      title: 'Spread Awareness',
      description:
        'Share our mission with your network. The more people who know, the faster help reaches those who need it most during critical moments.',
      buttonText: 'Learn More',
    },
  ];
}
