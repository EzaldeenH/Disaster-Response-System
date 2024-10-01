import { Component } from '@angular/core';
import {NgForOf} from "@angular/common";

@Component({
  selector: 'app-faq',
  standalone: true,
    imports: [
        NgForOf
    ],
  templateUrl: './faq.component.html',
  styleUrl: './faq.component.css'
})
export class FaqComponent {
  cards = [
    {
      title:
        "See how your donations are making a difference in communities affected by natural disasters.",
      buttonText: "Learn More",
    },
    {
      title: "Discover how you can contribute your time to help those in need.",
      buttonText: "Learn More",
    },
    {
      title:
        "Find out how to organize and raise funds effectively for disaster relief.",
      buttonText: "Learn More",
    },
  ];
}
