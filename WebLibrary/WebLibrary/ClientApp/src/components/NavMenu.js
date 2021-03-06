﻿import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
  displayName = NavMenu.name

  render() {
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={'/'}>Библиотека</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            
            <LinkContainer to={'/library'}>
                        <NavItem>
                            <Glyphicon glyph='education' /> Книги
              </NavItem>
                    </LinkContainer>
                    <LinkContainer to={'/orders'}>
                        <NavItem>
                            <Glyphicon glyph='th-list' /> На выдаче
              </NavItem>
                    </LinkContainer>

          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
