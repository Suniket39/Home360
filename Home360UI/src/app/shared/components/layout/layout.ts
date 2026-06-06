import { Component } from '@angular/core';
import { Navbar } from "./navbar/navbar";
import { Sidebar } from "./sidebar/sidebar";
import { RouterOutlet } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
@Component({
  selector: 'app-layout',
  imports: [Navbar, Sidebar, RouterOutlet],
  templateUrl: './layout.html',
  styleUrl: './layout.scss',
})
export class Layout {

  constructor( public authService : AuthService) {
  }
}
