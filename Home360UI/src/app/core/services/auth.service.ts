import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { LoginRequest, User } from '../../shared/components/models/loginRequest';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly TOKEN_KEY = 'access_token';

  private userSubject = new BehaviorSubject<User | null>(null);

  user$ : Observable<User | null> = this.userSubject.asObservable();

  private readonly API_URL = '/authenticate'

  constructor(private apiService : ApiService) {
    
  }

  login(credentials: LoginRequest){
    return this.apiService.post<any>('auth/authenticate', credentials);
  }

  saveToken(token : string){
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  getToken(): string | null{
    return localStorage.getItem(this.TOKEN_KEY);
  }

  isAuthenticated(): boolean {
    return !this.getToken();
  }

  logout(): void {
    localStorage.removeItem(this.TOKEN_KEY);
  }
}
