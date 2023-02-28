import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginModel } from 'src/app/models/auth';
import { AuthService } from '../../data-access/auth.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;

  constructor(
    private authService: AuthService,
    private fb: FormBuilder) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(): void{
    this.loginForm = this.fb.group({
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required]]
    })
  }

  onSubmit(){
    if (this.loginForm.invalid){
      return;
    }

    const loginModel: LoginModel = this.loginForm.value;
    this.authService.login(loginModel).subscribe(l => {
      console.log(l);
    })
  }
}
