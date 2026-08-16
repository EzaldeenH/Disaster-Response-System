import { Component } from '@angular/core';

@Component({
  selector: 'app-mission',
  standalone: true,
  imports: [],
  templateUrl: './mission.component.html',
})
export class MissionComponent {
  readonly pillars = [
    { icon: 'pi pi-home', title: 'Shelter', text: 'Emergency housing and rebuilding for displaced families.' },
    { icon: 'pi pi-heart', title: 'Medical Care', text: 'On-the-ground medical camps and supplies for affected regions.' },
    { icon: 'pi pi-bolt', title: 'Rapid Response', text: 'Teams deployed within 48 hours of a disaster striking.' },
  ];
}
