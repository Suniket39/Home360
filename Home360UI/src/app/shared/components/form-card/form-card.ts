import { Component, OnInit, signal } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import { ApiService } from '../../../core/services/api.service';
import { ToastifyManager } from '@andreasnicolaou/toastify';
import { form, FormField } from '@angular/forms/signals';

export interface LoginRequestModel {
  username: string;
  password: string;
}

@Component({
  selector: 'app-form-card',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, MatInputModule, FormField],
  templateUrl: './form-card.html',
  styleUrl: './form-card.scss',
})
export class FormCard implements OnInit{
  toast : ToastifyManager;
  private readonly model = signal<LoginRequestModel>({
    username: '',
    password: ''
  });

  readonly loginForm = form(this.model);

  constructor(private readonly apiService :ApiService) {
    this.toast = new ToastifyManager('top-right', {
      closeButton: true,
      withProgressBar: true,
      newestOnTop: true,
    });
  }

  ngOnInit(): void {
    
  }

  onLogin(): void{
    debugger
    var body = {
      username : this.model().username,
      password: this.model().password
    }

    this.apiService.post<any>("auth/authenticate", body).subscribe(
      {
        next: (data) =>
        {
          debugger
          console.log(data);
        },
        error: (err) =>
        {
          debugger
          this.toast.error('Error!', 'Something went wrong, please try again.',
            {
              duration: 10,
              progressBarDuration: 10,
            }
          );
        }
      }
    );
  }
}
