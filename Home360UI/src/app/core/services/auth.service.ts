import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { LoginRequest } from '../../shared/components/models/loginRequest';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly TOKEN_KEY = 'access_token';

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
