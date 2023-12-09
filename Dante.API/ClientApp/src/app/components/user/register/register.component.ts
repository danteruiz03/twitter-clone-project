import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from 'src/app/models/login.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  constructor(private userService: UserService, private router: Router) { }

  form = new FormGroup({
    username: new FormControl(''),
    password: new FormControl('')
  })

  submit() {
    const user: Login = {
      username: this.form.controls['username']?.value ?? '',
      password: this.form.controls['password']?.value ?? ''
    }

    this.userService.register(user).subscribe({
      next: () => {
        alert('Registered! Please sign in');
        this.router.navigateByUrl('/auth/login')
      },
      error: () => {
        alert('Something went wrong')
      }
    });
  }
}
