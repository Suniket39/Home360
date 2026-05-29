import { Component, DebugElement, OnInit, signal } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import { FormControl, FormGroup } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { ApiService } from '../../../core/services/api.service';
import { ToastifyManager } from '@andreasnicolaou/toastify';
import { form, Field, FormRoot,FormField , debounce, submit } from '@angular/forms/signals';

export interface LoginRequestModel {
  username: string;
  password: string;
}
@Component({
  selector: 'app-form-card',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, MatInputModule, ReactiveFormsModule],
  templateUrl: './form-card.html',
  styleUrl: './form-card.scss',
})
export class FormCard implements OnInit{

  form: FormGroup;
  toast : ToastifyManager;

  private readonly model = signal<LoginRequestModel>({
    username: '',
    password: ''
  });

  protected readonly loginForm = form<LoginRequestModel>(this.model, schema => {
    debounce(schema, 300);
  })

  constructor(private readonly apiService :ApiService) {
    this.form = new FormGroup({
      username: new FormControl(''),
      password: new FormControl(''),
    });

    this.toast = new ToastifyManager('top-right', {
      
      closeButton: true,
      withProgressBar: true,
      newestOnTop: true,
      
    });
    
  }

  ngOnInit(): void {
    
  }

  
  submit(){
    this.loadProducts();
  }

  loadProducts(): void{

    var body = {
      username : "Suniket",
      password: "Pass@123"
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
        });
  }
}
