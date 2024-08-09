import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [HttpClientModule, RouterModule],
  templateUrl: './home.component.html',
  styles: ``
})
export class HomeComponent implements OnInit {

  response!: string;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    const token = localStorage.getItem('token');

    this.http.get<string>('https://localhost:7198/home', {
      headers: { 'Authorization': `Bearer ${token}` }, responseType: 'text' as any
    }).subscribe({
      next: (r) => this.response = r,
      error: () => this.router.navigateByUrl('')
    })
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigateByUrl('');
  }

}
