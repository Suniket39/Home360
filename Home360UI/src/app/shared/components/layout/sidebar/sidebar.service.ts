import { Injectable, signal } from '@angular/core';

export interface NavItem {
  label: string;
  route: string;
  icon: string;
  badge?: string | number;
  children?: NavItem[];
}

export interface NavSection {
  title: string;
  items: NavItem[];
}

@Injectable({
  providedIn: 'root',
})
export class SidebarService {
  
  collapsed = signal<boolean>(false);

  toggle(): void {
    debugger
    this.collapsed.update(v => !v);
  }

  // sidebar = inject(SidebarService);
  readonly navSections: NavSection[] = [
    {
      title: 'Overview',
      items: [
        { label: 'Dashboard', route: '/dashboard', icon: 'layout-dashboard' },
        { label: 'Analytics', route: '/analytics', icon: 'chart-bar', badge: 'New' },
        { label: 'Users', route: '/users', icon: 'users' },
        { label: 'Projects', route: '/projects', icon: 'folder' },
      ],
    },
    {
      title: 'Workspace',
      items: [
        { label: 'Tasks', route: '/tasks', icon: 'clipboard-list', badge: 4 },
        { label: 'Calendar', route: '/calendar', icon: 'calendar' },
        { label: 'Messages', route: '/messages', icon: 'mail', badge: 2 },
        { label: 'Reports', route: '/reports', icon: 'report-analytics' },
      ],
    },
    {
      title: 'System',
      items: [
        { label: 'Settings', route: '/settings', icon: 'settings' },
        { label: 'Help & support', route: '/help', icon: 'help-circle' },
      ],
    },
  ];
}
