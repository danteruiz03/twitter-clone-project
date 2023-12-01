import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Login } from 'src/app/models/login.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  constructor(private userService: UserService) { }

  form = new FormGroup({
    username: new FormControl(''),
    password: new FormControl('')
  })

  submit() {
    const user: Login = {
      username: this.form.controls['username']?.value ?? '',
      password: this.form.controls['password']?.value ?? ''
    }

    this.userService.register(user).subscribe();
  }
}
