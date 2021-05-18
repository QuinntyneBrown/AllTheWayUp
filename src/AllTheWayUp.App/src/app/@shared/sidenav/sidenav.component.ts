import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent  {

  @Input() public navItems: any[] = [
    {
      label: "Drake",
      url: ["artist","Drake"]
    },
    {
      label: "Jay-Z",
      url: ["artist","Jay-Z"]
    },
    {
      label: "Lucy Pearl",
      url: ["artist","Lucy Pearl"]
    }        
  ];

}
