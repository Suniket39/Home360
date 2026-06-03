import { Component, OnInit, signal } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import { ToastifyManager } from '@andreasnicolaou/toastify';
import { form, FormField } from '@angular/forms/signals';
import { LoginRequest } from '../../../shared/components/models/loginRequest';
import { AuthService } from '../../../core/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [MatCardModule, MatButtonModule, MatInputModule, FormField],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login implements OnInit{
  toast : ToastifyManager;
  private readonly model = signal<LoginRequest>({
    username: '',
    password: ''
  });

  readonly loginForm = form(this.model);

  constructor(
    private readonly authService : AuthService,
    private readonly router : Router
  ) {
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

    this.authService.login(body).subscribe(
      {
        next: (data) =>
        {
          debugger
          console.log(data);
          this.authService.saveToken(data.accessToken);
          this.router.navigate(['/dashboard']);
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