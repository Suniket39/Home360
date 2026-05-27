import { Routes } from '@angular/router';
import { Login } from './features/auth/login/login';
import { FormCard } from './shared/components/form-card/form-card';

export const routes: Routes = [
    { path: '', redirectTo: 'login', pathMatch: 'full' }, // Redirects home to login
    { path: 'login', component : Login},
    { path: 'form', component : FormCard},
    
];
