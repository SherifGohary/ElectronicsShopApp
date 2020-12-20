import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryService } from 'src/app/Category/Services/category.service';
import { EditorMode } from 'src/app/Shared/Models/editor-mode.enum';
import { NotificationService } from 'src/app/Shared/Services/notification.service';
import { User } from '../../Models/user';
import { UserService } from '../../Services/user.service';
import { Location } from '@angular/common';
import { Role } from '../../Models/role.enum';

@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.scss']
})
export class EditorComponent implements OnInit {


  editorForm: FormGroup;
  editorMode: EditorMode = EditorMode.add;
  editorModeEnum = EditorMode;
  itemModel: User = new User();
  isProccessing: boolean;
  id: number;
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
    this.extractRouteParams();
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      fullName: [null, [Validators.required]],
      userName: [null, [Validators.required]],
      password: [null, [Validators.required]],
      email: [null, [Validators.required]],
      country: [null, [Validators.required]],
      city: [null, [Validators.required]],
      address: [null, [Validators.required]],
      birthDate: [null, [Validators.required]],
      phoneNumber: [null, [Validators.required]],
      role:[Role.User]
    });
  }


  bindModelToForm(): void {
    if (this.itemModel) {
      this.editorForm.patchValue({
        id: this.itemModel.id,
        fullName: this.itemModel.fullName,
        userName: this.itemModel.userName,
        password: this.itemModel.password,
        email: this.itemModel.email,
        country: this.itemModel.country,
        city: this.itemModel.city,
        address: this.itemModel.address,
        birthDate: this.itemModel.birthDate,
        phoneNumber: this.itemModel.phoneNumber,
        role: this.itemModel.role,
      });
    }
  }


  extractRouteParams(): void {
    let editId = +this.route.snapshot.params['editId'];
    let detailId = +this.route.snapshot.params['detailId'];

    if (editId) {
      this.editorMode = EditorMode.edit
      this.id = editId;
    }
    else if (detailId) {
      this.editorMode = EditorMode.detail;
      this.id = detailId;
    }
    else {
      this.editorMode = EditorMode.add;
    }

    if (this.id) {
      this.userService.getUser(this.id)
        .subscribe(res => {
          this.itemModel = res;
          this.bindModelToForm();
        },
          (error) => {
            this.notificationService.showError("error");
          })
    }
  }


  canEdit(): boolean {
    return this.editorMode != EditorMode.detail;
  }

  collectModelFromForm(): void {
    this.itemModel = this.editorForm.value;
    if(this.id){
      this.itemModel.id = this.id;
    }
  }

  gotoList() {
    let url = [`/product/list`];
    this.router.navigate(url);
  }

  save(): void {
    if (this.canEdit()) {
      this.isProccessing = true;

      if (this.editorForm.valid) {
        if (this.editorMode == EditorMode.add) {
          this.collectModelFromForm();
          this.itemModel.role = Role.User;
          this.userService.addUser(this.itemModel)
            .subscribe(res => {
              this.notificationService.showSuccess("User added Successfully");
              this.gotoList();
            },
              (error) => {
                this.isProccessing = false;               
                console.log(error);
              });
        }
        else if (this.editorMode == EditorMode.edit) {
          this.collectModelFromForm();
          this.itemModel.role = Role.User;
          this.userService.updateUser(this.itemModel)
            .subscribe(res => {
              this.notificationService.showSuccess("User updated successfully");
              this.gotoList();
            },
              (error) => {
                this.isProccessing = false;
                console.log(error);
              });
        }
      }
      else {
        this.isProccessing = false;
        this.notificationService.showError("error");
      }
    }
  }

  goToBack() {
    this.location.back();
  }


}
