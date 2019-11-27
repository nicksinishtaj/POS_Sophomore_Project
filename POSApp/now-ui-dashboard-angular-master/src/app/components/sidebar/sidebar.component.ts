import { Component, OnInit } from '@angular/core';

declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: '/dashboard', title: '',  icon: 'design_app', class: '' },
    { path: '/icons', title: '',  icon:'education_atom', class: '' },
    { path: '/maps', title: 'Inventory Totals',  icon:'location_map-big', class: '' },
    { path: '/notifications', title: 'Create Ticket',  icon:'ui-1_bell-53', class: '' },

    { path: '/user-profile', title: 'Cash Out',  icon:'users_single-02', class: '' },
    { path: '/table-list', title: 'Table Layout',  icon:'design_bullet-list-67', class: '' },
    { path: '/typography', title: 'Tip Totals',  icon:'text_caps-small', class: '' },
    { path: '/upgrade', title: '',  icon:'objects_spaceship', class: 'active active-pro' }

];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor() { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
      if ( window.innerWidth > 991) {
          return false;
      }
      return true;
  };
}
