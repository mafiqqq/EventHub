import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private http: HttpClient) {}

  title = 'EventHub';
  events: any;

  ngOnInit(): void {
    // This returns an observable
    // Therefore we would need to subscribe to it
    this.http.get('https://localhost:5000/api/events').subscribe({
      next: res => this.events = res,
      error: error => console.log(error),
      complete: () => console.log('Req completed') 
    })

    
  }

}
