import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { AuthService } from 'src/app/services/auth.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  constructor(
    private userService: UserService,
    private authService: AuthService,
    private router: Router) { }

  form = new FormGroup({
    username: new FormControl(''),
    password: new FormControl('')
  })

  submit() {
    const user: User = {
      username: this.form.controls['username']?.value ?? '',
      password: this.form.controls['password']?.value ?? ''
    }

    this.userService.login(user).subscribe(token => {
      this.authService.storeToken(token);
      this.router.navigateByUrl('');
    });
  }
}
