using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace cocos2d
{
    public enum tCCMenuState
	{
        kCCMenuStateWaiting,
        kCCMenuStateTrackingTouch
    };

    public class CCMenu : CCLayer, CCRGBAProtocol
    {
        const float kDefaultPadding =  5;

		protected tCCMenuState m_eState;
		protected CCMenuItem m_pSelectedItem;		

        public CCMenu()
		{
            m_cOpacity = 0;
			m_pSelectedItem = null;
        }

        /** creates an empty CCMenu */
        public static CCMenu node()
        {
            CCMenu menu = new CCMenu();

            if (menu != null && menu.init()) 
            {
                return menu;
            }

            return null;
        }

        ///** creates a CCMenu with it's items */
        public static CCMenu menuWithItems(params CCMenuItem[] item)
        {
		    CCMenu pRet = new CCMenu();

		    if (pRet != null && pRet.initWithItems(item))
		    {
			    return pRet;
		    }

		    return null;
        }

		/** creates a CCMenu with it's item, then use addChild() to add 
		  * other items. It is used for script, it can't init with undetermined
		  * number of variables.
		*/
		public static CCMenu menuWithItem(CCMenuItem item)
        {
            return menuWithItems(item, null);
        }

        /** initializes an empty CCMenu */
        public bool init()
        {
            return initWithItems(null);
        }

        ///** initializes a CCMenu with it's items */
        bool initWithItems(params CCMenuItem[] item)
        { 
            if (base.init())
		    {
			    this.m_bIsTouchEnabled = true;

			    // menu in the center of the screen
			    CCSize s = CCDirector.sharedDirector().getWinSize();

			    this.m_bIsRelativeAnchorPoint = false;
			    anchorPoint = new CCPoint(0.5f, 0.5f);
			    this.contentSize = s;

			    // XXX: in v0.7, winSize should return the visible size
			    // XXX: so the bar calculation should be done there
			    CCRect r;
                CCApplication.sharedApplication().statusBarFrame(out r);

			    ccDeviceOrientation orientation = CCDirector.sharedDirector().deviceOrientation;
			    if (orientation == ccDeviceOrientation.CCDeviceOrientationLandscapeLeft 
                    || 
                    orientation == ccDeviceOrientation.CCDeviceOrientationLandscapeRight)
			    {
				    s.height -= r.size.width;
			    }
			    else
			    {
				    s.height -= r.size.height;
			    }
			    
                position = new CCPoint(s.width/2, s.height/2);

			    int z=0;

			    if (item != null)
			    {
                    foreach (var menuItem in item)
                    {
                        this.addChild(menuItem);
                    }
			    }
			    //	[self alignItemsVertically];

			    m_pSelectedItem = null;
                m_eState = tCCMenuState.kCCMenuStateWaiting;
			    return true;
		    }

		    return false;
        }

		/** align items vertically */
		public void alignItemsVertically()
        {
            this.alignItemsVerticallyWithPadding(kDefaultPadding);
        }

		/** align items vertically with padding
		@since v0.7.2
		*/
		public void alignItemsVerticallyWithPadding(float padding)
        {
            float height = -padding;

		    if (m_pChildren != null && m_pChildren.Count > 0)
		    {
                foreach (var pChild in m_pChildren)
                {
                    if (pChild != null)
                    {
                        height += pChild.contentSize.height * pChild.scaleY + padding;
                    }
                }
		    }

		    float y = height / 2.0f;
		    if (m_pChildren != null && m_pChildren.Count > 0)
		    {
                foreach (var pChild in m_pChildren)
                {
                    if (pChild != null)
                    {
                        pChild.position = new CCPoint(0, y - pChild.contentSize.height * pChild.scaleY / 2.0f);
                        y -= pChild.contentSize.height * pChild.scaleY + padding;
                    }
                }
		    }
        }

		/** align items horizontally */
		public void alignItemsHorizontally()
        {
            this.alignItemsHorizontallyWithPadding(kDefaultPadding);
        }

		/** align items horizontally with padding
		@since v0.7.2
		*/
		public void alignItemsHorizontallyWithPadding(float padding)
        {
            float width = -padding;

		    if (m_pChildren != null && m_pChildren.Count > 0)
		    {
                foreach (var pChild in m_pChildren)
                {
                    if (pChild != null)
                    {
                        width += pChild.contentSize.width * pChild.scaleX + padding;
                    }
                }
		    }

		    float x = -width / 2.0f;
		    if (m_pChildren != null && m_pChildren.Count > 0)
		    {
                foreach (var pChild in m_pChildren)
                {
                    if (pChild != null)
                    {
                        pChild.position = new CCPoint(x + pChild.contentSize.width * pChild.scaleX / 2.0f, 0);
     				    x += pChild.contentSize.width * pChild.scaleX + padding;
                    }
                }
		    }
        }

		/** align items in rows of columns */
        //void alignItemsInColumns(unsigned int columns, ...);
        //void alignItemsInColumns(unsigned int columns, va_list args);

		/** align items in columns of rows */
        //void alignItemsInRows(unsigned int rows, ...);
        //void alignItemsInRows(unsigned int rows, va_list args);

		//super methods
		public virtual void addChild(CCNode child, int zOrder)
        {
            base.addChild(child, zOrder);
        }

		public virtual void addChild(CCNode child, int zOrder, int tag)
        {
            base.addChild(child, zOrder, tag);
        }

		public virtual void registerWithTouchDispatcher()
        {
            throw new NotImplementedException();

              #warning "Wait for CCTouchDispatcher"
            // CCTouchDispatcher::sharedDispatcher()->addTargetedDelegate(this, kCCMenuTouchPriority, true);
        }

        /**
        @brief For phone event handle functions
        */
        public virtual bool ccTouchBegan(CCTouch touch, CCEvent ccevent)
        {
            if (m_eState != tCCMenuState.kCCMenuStateWaiting || !m_bIsVisible)
		    {
			    return false;
		    }

		    for (CCNode c = this.m_pParent; c != null; c = c.parent)
		    {
			    if (c.visible == false)
			    {
				    return false;
			    }
		    }

		    m_pSelectedItem = this.itemForTouch(touch);

		    if (m_pSelectedItem != null)
		    {
                m_eState = tCCMenuState.kCCMenuStateTrackingTouch;
			    m_pSelectedItem.selected();

			    return true;
		    }

		    return false;
        }

        public virtual void ccTouchEnded(CCTouch touch, CCEvent ccevent)
        {
            Debug.Assert(m_eState == tCCMenuState.kCCMenuStateTrackingTouch, "[Menu ccTouchEnded] -- invalid state");

            if (m_pSelectedItem != null)
            {
                m_pSelectedItem.unselected();
                m_pSelectedItem.activate();
            }

            m_eState = tCCMenuState.kCCMenuStateWaiting;
        }

        public virtual void ccTouchCancelled(CCTouch touch, CCEvent ccevent)
        {
            Debug.Assert(m_eState == tCCMenuState.kCCMenuStateTrackingTouch, "[Menu ccTouchCancelled] -- invalid state");

            if (m_pSelectedItem != null)
            {
                m_pSelectedItem.unselected();
            }

            m_eState = tCCMenuState.kCCMenuStateWaiting;
        }

        public virtual void ccTouchMoved(CCTouch touch, CCEvent ccevent)
        {
            Debug.Assert(m_eState == tCCMenuState.kCCMenuStateTrackingTouch, "[Menu ccTouchMoved] -- invalid state");

            CCMenuItem currentItem = this.itemForTouch(touch);

            if (currentItem != m_pSelectedItem)
            {
                if (m_pSelectedItem != null)
                {
                    m_pSelectedItem.unselected();
                }

                m_pSelectedItem = currentItem;

                if (m_pSelectedItem != null)
                {
                    m_pSelectedItem.selected();
                }
            }
        }

		public virtual void destroy()
        {
            //release();            
        }

		public virtual void keep()
        {
            //throw new NotImplementedException();
        }

        /**
        @since v0.99.5
        override onExit
        */
        public virtual void onExit()
        {
            if (m_eState == tCCMenuState.kCCMenuStateTrackingTouch)
            {
                m_pSelectedItem.unselected();
                m_eState = tCCMenuState.kCCMenuStateWaiting;
                m_pSelectedItem = null;
            }

            base.onExit();
        }

		public virtual CCRGBAProtocol convertToRGBAProtocol() 
        { 
            return (CCRGBAProtocol)this; 
        }

        protected CCMenuItem itemForTouch(CCTouch touch)
        {
            CCPoint touchLocation = touch.locationInView(touch.view());
		    touchLocation = CCDirector.sharedDirector().convertToGL(touchLocation);

            if (m_pChildren != null && m_pChildren.Count > 0)
		    {
                foreach (var pChild in m_pChildren)
                {
                    if (pChild != null && pChild.visible && ((CCMenuItem)pChild).Enabled)
                    {
                        CCPoint local = pChild.convertToNodeSpace(touchLocation);
					    CCRect r = ((CCMenuItem)pChild).rect();
                        r.origin = CCPoint.Zero;

					    if (CCRect.CCRectContainsPoint(r, local))
					    {
						    return (CCMenuItem)pChild;
					    }
                    }
                }
			
		    }

		    return null;
        }

        #region CCRGBAProtocol Interface

        protected ccColor3B m_tColor;
        protected byte m_cOpacity;

        public ccColor3B Color
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public byte Opacity
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsOpacityModifyRGB
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}