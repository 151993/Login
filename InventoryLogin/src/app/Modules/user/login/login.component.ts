import { Component,  OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserService } from './user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {
  subscription: Subscription;
  form: FormGroup = new FormGroup({});
  submitted = false;
  constructor(
    private userService: UserService,
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.FormBuilder();
  }

  FormBuilder = (): void => {
    this.form = this.fb.group({
      userName: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  Login = (): void => {
    const username = this.form.get('userName').value;
    const password = this.form.get('password').value;
    if (username === '' || password === '') {
      alert('please enter username & password');
      return;
    }
    this.submitted = true;
    if (this.form.invalid) {
      return;
    }
    this.subscription = this.userService.Login(username, password).subscribe(response => {
      if (response.isSuccess) {
        this.router.navigate(['product/list']);
      }
      else {
        alert(response.errorMessage);
      }
    });
  }

  // tslint:disable-next-line: typedef
  get f() { return this.form.controls; }

  ngOnDestroy = (): void => {
    if (this.subscription) { this.subscription.unsubscribe(); }
  }

}
