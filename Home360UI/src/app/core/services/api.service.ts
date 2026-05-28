import { inject, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpContext } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Login } from '../../shared/components/models/login';
import { QueryParamsHandling } from '@angular/router';

@Injectable({
  providedIn: 'root',
})

export class ApiService {

  private readonly http = inject(HttpClient);
  private readonly apiUrl = 'http://localhost:5000/api';
    // private readonly baseUrl = environment.apiUrl; // Add in env

    
  getLogin(): Observable<Login[]>{
    return this.http.get<Login[]>(this.apiUrl);
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
}

export interface QueryParams {
  [key: string]: string | number;
}