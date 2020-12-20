import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationService } from 'src/app/Shared/Services/notification.service';
import { Login } from '../../Models/login';
import { User } from '../../Models/user';
import { UserService } from '../../Services/user.service';
import { Location } from '@angular/common';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  editorForm: FormGroup;
  itemModel: Login = new Login();
  isProccessing: boolean;
  filterSettings:any;



  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private notificationService: NotificationService,
    private location: Location
  ) { }

  ngOnInit() {
    this.buildForm();
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      userName: [null, [Validators.required]],
      password: [null, [Validators.required]]
    });
  }

  collectModelFromForm(): void {
    this.itemModel = this.editorForm.value;
  }

  gotoList() {
    let url = [`/product/list`];
    this.router.navigate(url);
  }

  save(): void {
      this.isProccessing = true;

      if (this.editorForm.valid) {
          this.collectModelFromForm();
          this.userService.login(this.itemModel)
            .subscribe(res => {
              if(res["userName"] == this.itemModel.userName){
                localStorage.setItem('currentUser', JSON.stringify(res));
                this.gotoList();
              }
            },
              (error) => {
                this.isProccessing = false;               
                console.log(error);
              });
        }
    }
}
