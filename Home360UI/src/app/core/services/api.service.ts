import { inject, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpContext } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginRequest } from '../../shared/components/models/loginRequest';
import { QueryParamsHandling } from '@angular/router';

@Injectable({
  providedIn: 'root',
})

export class ApiService {

  private readonly http = inject(HttpClient);
  private readonly apiUrl = 'http://localhost:5260/api';
    // private readonly baseUrl = environment.apiUrl; // Add in env

    
  getLogin(): Observable<LoginRequest[]>{
    return this.http.get<LoginRequest[]>(this.apiUrl);
  }

  get<T>(
    route: string,
    skipAuth: boolean = false,
    params: QueryParams = {},
    id: number | null,
    method: 'get' | 'delete' = 'get'
  ) : Observable<T>{
    return this.http.get<T>(`${this.apiUrl}/${route}${id ? '/' + id: ''}`);
  }

  post<T>(
    route: string,
    data: T,
    params: QueryParams = {},
  ) : Observable<T>{
    debugger
    return this.http.post(`${this.apiUrl}/${route}`, data) as Observable<T>;
  }

  patch<T>(
    route: string,
    data: T,
    params: QueryParams = {},
  ) : Observable<T>{
    return this.http.patch(`${this.apiUrl}/${route}`, data) as Observable<T>;
  }
}

export interface QueryParams {
  [key: string]: string | number;
}