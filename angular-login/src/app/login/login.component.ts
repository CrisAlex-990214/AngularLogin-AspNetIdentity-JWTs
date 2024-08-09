import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, HttpClientModule, RouterModule],
  templateUrl: './login.component.html',
  styles: ``
})
export class LoginComponent {

  email!: string;
  password!: string;

  constructor(private http: HttpClient, private router: Router) { }

  login() {
    this.http.post<string>('https://localhost:7198/login', { email: this.email, password: this.password },
      { responseType: 'text' as any }
    ).subscribe(t => {
      localStorage.setItem('token', t);
      this.router.navigateByUrl('home');
    });
  }
}
