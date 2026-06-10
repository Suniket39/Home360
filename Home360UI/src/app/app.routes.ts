import { Routes } from '@angular/router';
import { Login } from './features/auth/login/login';
import { FormCard } from './shared/components/form-card/form-card';
import { GlobalDashboard } from './features/dashboard/global-dashboard/global-dashboard';
import { authGuard } from './core/services/auth-guard';
import { User } from './features/user-manager/user/user';

export const routes: Routes = [
    { path: '', redirectTo: 'login', pathMatch: 'full' }, // Redirects home to login
    { path: 'login', component : Login},
    { path: 'form', component : FormCard},
    { path: 'dashboard', component : GlobalDashboard, canActivate: [authGuard]},
    { path: 'users', component : User},
    
];
