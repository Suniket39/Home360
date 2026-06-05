import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Layout } from './shared/components/layout/layout';

@Component({
  selector: 'app-root',
  imports: [Layout],
  // templateUrl: './app.html',
  template : '<app-layout></app-layout>',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('Home360UI');
}
