import { Component } from '@angular/core';

@Component({
  selector: 'app-news',
  standalone: true,
  imports: [],
  templateUrl: './news.component.html',
})
export class NewsComponent {
  readonly newsItems = [
    {
      title: 'Aid in Turkey',
      category: 'Earthquake Relief',
      date: 'March 5, 2023',
      description:
        'Our team in Turkey distributed essential supplies to earthquake victims. Within 48 hours of the 7.8 magnitude quake, we had teams on the ground in Gaziantep distributing tents, blankets, and hot meals to families left homeless in the freezing winter conditions.',
    },
    {
      title: 'Haiti Rebuild',
      category: 'Hurricane Recovery',
      date: 'April 15, 2023',
      description:
        'Rebuilding homes in Haiti after the devastating hurricane. Six months after the storm, we continue to work alongside local builders to construct permanent housing for families still living in temporary shelters, with 40 homes completed so far.',
    },
    {
      title: 'Medical Camp',
      category: 'Flood Response',
      date: 'May 12, 2023',
      description:
        'A medical camp was set up in Bangladesh to treat flood victims. Our volunteer doctors and nurses treated over 800 patients in the first week alone, addressing waterborne illnesses, injuries, and providing essential medications to remote communities.',
    },
  ];
}
