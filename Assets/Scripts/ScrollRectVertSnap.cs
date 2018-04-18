using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class ScrollRectVertSnap : MonoBehaviour {
	private GameObject scroll;
	private RectTransform _scrollRect;
	private VerticalLayoutGroup _vertScroll;
	private bool _isScrolling;
	private float _scrollPos;
	private float _scrollBottom;
	private float _scrollHeight;
	private float _totalHeight = 0;
	private int _childCount;
	private Vector2 _scrollVector;

	private void Start() {
		scroll = gameObject;
		_scrollRect = scroll.GetComponent<ScrollRect>().GetComponent<RectTransform>();
		_vertScroll = scroll.GetComponent<VerticalLayoutGroup>();
		_scrollHeight = _scrollRect.rect.height;
		_childCount = scroll.transform.childCount;
		for (int i = 0; i < _childCount; i++) {
			_totalHeight += scroll.transform.GetChild(i).GetComponent<RectTransform>().rect.height + _vertScroll.spacing;
		}
		_scrollBottom = _totalHeight - _scrollHeight;
	}

	private void FixedUpdate() {
		_scrollVector = _scrollRect.anchoredPosition;
		_scrollPos = _scrollVector.y;
		if (_isScrolling)
			return;
		if (_scrollPos < 0 || _scrollPos > _scrollBottom) {
			_scrollVector.y = (_scrollPos < 0) ? 0 : _scrollBottom;
			scroll.GetComponent<ScrollRect>().velocity = Vector2.zero;
			_scrollRect.anchoredPosition = _scrollVector;
			scroll.GetComponent<ScrollRect>().inertia = false;
		}
		scroll.GetComponent<ScrollRect>().inertia = true;
	}

	public void Scrolling(bool state) {
		_isScrolling = state;
	}
}