import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;


  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.createLoginForm();
  }

  // tslint:disable-next-line: typedef
  createLoginForm() {
    this.loginForm = new FormGroup ({
      email: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required)
    });
  }

  // tslint:disable-next-line: typedef
  onSubmit() {
    this.accountService.login(this.loginForm.value).subscribe(() => {
      console.log('user logged in');
    }, error => {
      console.log(error);
    });
  }
  /* 
method from the service for reference:
login(values: any) {
    return this.http.post(this.baseUrl + 'account/login', values).pipe(
      map((user: IUser) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        }
      })
    );
  }
  */
}
