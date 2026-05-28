import { Component, DebugElement } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import { FormControl, FormGroup } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-form-card',
  imports: [MatCardModule, MatButtonModule, MatInputModule, ReactiveFormsModule],
  templateUrl: './form-card.html',
  styleUrl: './form-card.scss',
})
export class FormCard {

  form: FormGroup = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });

  submit(){

  }
}
