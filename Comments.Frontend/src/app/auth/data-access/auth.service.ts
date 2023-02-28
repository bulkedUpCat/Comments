import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { JwtTokenModel, LoginModel } from 'src/app/models/auth';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(loginModel: LoginModel): Observable<JwtTokenModel>{
    return this.http.post<JwtTokenModel>(environment.apiUrl + 'auth/login', loginModel);
  }
}
