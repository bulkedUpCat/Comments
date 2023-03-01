import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthService } from '../auth/data-access/auth.service';


@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private authService: AuthService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        var isAuthenticated: boolean = false;
        this.authService.isAuthenticated.subscribe(a => {
          isAuthenticated = a;
        })

        var token = localStorage.getItem('token');
        const isApiUrl = request.url.startsWith(environment.apiUrl);

        console.log(this.authService.isAuthenticated.value);

        if (isAuthenticated && isApiUrl) {
            request = request.clone({
                setHeaders: { Authorization: `Bearer ${token}` }
            });
        }

        return next.handle(request);
    }
}
