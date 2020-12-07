import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { MustMatch } from 'src/app/Common/must-match.validator';
import { User } from 'src/app/Models/user';
import { UserService } from '../login/user.service';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit, OnDestroy {
  registerForm: FormGroup = new FormGroup({});
  submitted = false;
  user: User;
  subscription: Subscription;
  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private router: Router) { }

  ngOnInit(): void {
    this.FormBuilder();
  }

  FormBuilder = (): void => {
    this.user = { FirstName: '', LastName: '', EmailId: '', UserName: '', Password: '', IsActive: true };
    this.registerForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required],
    }, {
      validator: MustMatch('password', 'confirmPassword')
    });
  }
  // tslint:disable-next-line: typedef
  get f() { return this.registerForm.controls; }

  onSubmit = (): any => {
    this.submitted = true;

    if (this.registerForm.invalid) {
      return;
    }
    this.user =
    {
      FirstName: this.registerForm.get('firstName').value,
      LastName: this.registerForm.get('lastName').value,
      EmailId: this.registerForm.get('email').value,
      UserName: this.registerForm.get('email').value,
      Password: this.registerForm.get('password').value,
      IsActive: true
    };

    this.subscription = this.userService.Save(this.user).subscribe(response => {
      if (response.isSuccess) {
        alert(response.successMessage);
        this.onReset();
        this.router.navigate(['/']);
      }
      else {
        alert(response.errorMessage);
        // this.onReset();
      }
    });
  }

  onReset = (): void => {
    this.submitted = false;
    this.registerForm.reset();
  }

  ngOnDestroy = (): void => {
    if (this.subscription) { this.subscription.unsubscribe(); }
  }

}
