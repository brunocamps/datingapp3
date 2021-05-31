import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'The Dating app';
  users: any;

  // to print users on console you need the HTTP client on the CTOR
  // 
  constructor(private accountService: AccountService) {} 

  ngOnInit() {
    this.setCurrentUser();
    
}

setCurrentUser() {
  const user: User = JSON.parse(localStorage.getItem('user'));
  this.accountService.setCurrentUser(user);
}

// show users on browser console
// getUsers(){
//   // use our http service
//   this.http.get('https://localhost:5001/api/users').subscribe(response => {
//     this.users = response;
//   }, error => {
//     console.log(error);
//   })
// }
}
