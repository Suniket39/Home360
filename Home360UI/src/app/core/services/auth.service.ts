import { Injectable, signal } from '@angular/core';
import { ApiService } from './api.service';
import { LoginRequest, User } from '../../shared/components/models/loginRequest';
import { BehaviorSubject, Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly TOKEN_KEY = 'access_token';

//  private loggedIn = new BehaviorSubject<boolean>(false);

 isAuthenticated = signal(
  !!localStorage.getItem(this.TOKEN_KEY)
 );
  // get isLoggedIn() {
  //   return this.loggedIn.asObservable(); // {2}
  // }

  constructor(
    private apiService : ApiService,
    private router : Router
  ) {
    
  }

  login(credentials: LoginRequest){
    return this.apiService.post<any>('auth/authenticate', credentials);
  }

  logout(): void {
    localStorage.removeItem(this.TOKEN_KEY);
    this.isAuthenticated.set(false);
    this.router.navigate(['/login']);
  }

  saveToken(token : string): void{
    localStorage.setItem(this.TOKEN_KEY, token);
    this.isAuthenticated.set(true);
  }

  getToken(): string | null{
    return localStorage.getItem(this.TOKEN_KEY);
  }

  // isAuthenticated(): boolean {
  //   return !this.getToken();
  // }
}
