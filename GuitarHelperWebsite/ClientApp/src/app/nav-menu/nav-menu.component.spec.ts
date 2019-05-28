import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { NavMenuComponent } from './nav-menu.component';
import { RouterTestingModule } from '@angular/router/testing';

describe('NavMenuComponent', () => {
  let component: NavMenuComponent;
  let fixture: ComponentFixture<NavMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ RouterTestingModule ],
      declarations: [ NavMenuComponent ]
    })
      .compileComponents()
      .then(() => {
        fixture = TestBed.createComponent(NavMenuComponent);
        component = fixture.componentInstance;
      });
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('toggle() sets isExpanded on and off', () => {
    expect(component.isExpanded).toBe(false, 'off at first');
    component.toggle();
    expect(component.isExpanded).toBe(true, 'on after click');
    component.toggle();
    expect(component.isExpanded).toBe(false, 'off after second click');
  });
});
