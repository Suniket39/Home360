import { ChangeDetectorRef, Component, OnInit, signal } from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import { ApiService } from '../../../core/services/api.service';
import { CommonModule } from '@angular/common';
import { GenericTable } from '../../../shared/components/generic-table/generic-table';


@Component({
  selector: 'app-user',
  imports: [MatTableModule, CommonModule, GenericTable ],
  templateUrl: './user.html',
  styleUrl: './user.scss',
})
export class User implements OnInit {

  // allUsers : any[] = [];
  allUsers = signal<any[]>([]);

    // Pagination
  private _currentActivePage: number = 1;
  public get currentActivePage(): number {
    return this._currentActivePage;
  }
  public set currentActivePage(value: number) {
    this._currentActivePage = value;
  }
  pageSize = 15;
  pageSizeOptions = [15, 30, 50, 100];
  totalRecords: number = 0;
  paginationId = 'users';

  constructor(private apiService : ApiService,
    private cdr: ChangeDetectorRef
  ) {
    
  }

  ngOnInit(){
    this.getAllUsers();
  }

  getAllUsers(){

    this.apiService.get<any>('UserManager/allUsers', {}, null).subscribe({
      next: (response) => {
        debugger
        // this.allUsers = this.prepareTableData(response);
         this.allUsers.set(this.prepareTableData(response));
        // this.cdr.markForCheck();
      },
      error: (error) =>{
        debugger
      }
    })

  }

  columns = [
  { label: 'Sr. No.', key: 'index', type: 'index' },
  { label: 'User Name', key: 'username' },
  { label: 'First Name', key: 'firstName' },
  { label: 'Last Name', key: 'lastName' },
  { label: 'Email', key: 'email' },
  { label: 'Mobile Number', key: 'mobileNumber' },
  // { label: 'Created Date', key: 'createdDate', type: 'date' },
  // { label: 'Status', key: 'isActive', type: 'status' },
  // { label: 'Action', key: 'action', type: 'action' }
];

prepareTableData(apiData: any[]) {
    return apiData.map((item, index) => ({
      index: (this.currentActivePage - 1) * this.pageSize + index + 1,

      userId: item.accountAssignmentId,
      username: item.username,
      firstName: item.firstName,
      lastName: item.lastName,
      email: item.email,
      mobileNumber: item.mobileNumber,
      // createdDate: item.createdDate,
      // isActive: item.isActive,
      __original: item // for edit/delete/view
    }));
  }

}
