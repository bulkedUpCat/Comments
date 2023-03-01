import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/data-access/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  isAuthenticated: boolean = false;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.authService.isAuthenticated.subscribe(a => {
      this.isAuthenticated = a;
    })
  }

  onLogout(){
    this.authService.logout();
  }
}
