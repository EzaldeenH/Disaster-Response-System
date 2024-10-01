import { Component } from '@angular/core';
import {NgForOf} from "@angular/common";

@Component({
  selector: 'app-news',
  standalone: true,
    imports: [
        NgForOf
    ],
  templateUrl: './news.component.html',
  styleUrl: './news.component.css'
})
export class NewsComponent {
  newsItems = [
    {
      title: "Aid in Turkey",
      date: "March 5, 2023",
      description:
        "Our team in Turkey distributed essential supplies to earthquake victims.",
      image: "assets/turkey-aid.jpg",
    },
    {
      title: "Haiti Rebuild",
      date: "April 15, 2023",
      description: "Rebuilding homes in Haiti after the devastating hurricane.",
      image: "assets/haiti-rebuild.jpg",
    },
    {
      title: "Medical Camp",
      date: "May 12, 2023",
      description:
        "A medical camp was set up in Bangladesh to treat flood victims.",
      image: "assets/medical-camp.jpg",
    },
  ];

}
